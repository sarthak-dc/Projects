/** 
 * Lab 3
 * Sarthak Thukran
 * 21st March, 2023
 * Durham College 
**/

/**
 * This function creates 20 post cards and sets each card's ID using a for loop.
 * It also creates all the necessary HTML elements for a post, such as title, image, and text.
 * At the end, it calls two functions to populate the data with images, titles, and the content of the post.
 */
const makePosts = () => {
    // Loop through 20 times to create 20 posts
    for (let i = 0; i < 20; i++) {
        // Set variables for ID and post number
        let idNum = i;
        let postNum = i+1;

        // Creating all necessary HTML elements for a post card
        let card = $(`<div class="card blog text-center"></div>`).attr("id", `card-${idNum}`).appendTo($(".blog-column"));

        let body = $(`<div class="card-body blog"></div>`).attr("id", `card-body-${idNum}`).appendTo(card);

        let br = $(`<br>`).appendTo($(".blog-column"));

        let title = $(`<h5 class="card-title blog"></h5>`).attr("id", `card-title-${idNum}`).appendTo(body);
        
        let pic = $("<img>").attr("id", `img-${idNum}`).addClass("blog-pic").css("max-height", "100px").appendTo(body);
        
        let sub = $(`<p class="userId blog"></p>`).attr("id", `sub-${idNum}`).appendTo(body);

        let post_id = $(`<span></span>`).attr("id", `post-${idNum}`).text(`Post #${postNum}: `).appendTo(sub);
        
        let text = $(`<p class="card-text blog"></p>`).attr("id", `card-text-${idNum}`).appendTo(sub);

        let user_id = $(`<span></span>`).attr("id", `user-${idNum}`).appendTo(sub);

        // Call the getPictures function to get pictures for each post
        getPictures();
        // Call the getPosts function to get post data for each post
        getPosts();
    }
}


/**
 * This function is used to get pictures from Pixabay using my account's API key.
 * It utilizes fetch to get data from the specified URL and then puts the images inside the appropriate HTML img element.
 */
const getPictures = () => {
    // Set Pixabay API key and URL
    PIXABAY_KEY = "34271658-b6a1808a11231872bf5f80761";
    PIXABAY_URL = "https://pixabay.com/api/?key=<KEY>&q=racecar&image_type=photo&per_page=21";
    // Replace the <KEY> placeholder with the actual API key
    const url = PIXABAY_URL.replace("<KEY>", PIXABAY_KEY);
    
    // Initialize an empty array to store the fetched images
    let pics = [];
    // Fetch data from the Pixabay URL
    fetch(url)
        .then((res) => {
            return res.json();
        })
        .then((jsonRes) => {
            // Save the pictures into the pics array
            pics = jsonRes["hits"];
            // Loop through each image element and set its src and alt attributes
            for (let i = 0; i < 20; i++) {
                $(`#img-${i}`).attr("src", pics[i]["webformatURL"])
                let altText = jsonRes["hits"][i]["tags"];
                $(`#img-${i}`).attr("alt", altText);
            }
        })
        // Handles any errors generated
        .catch(err => console.log(err));
}


/**
 * This function is used to get posts from a URL. This function utilizes fetch to get data from the specified URL and then put all the necessary data inside the appropriate HTML elements
 */
const getPosts = () => {
    const url = "https://jsonplaceholder.typicode.com/posts";

    fetch(
        url
    )
    .then((res) => {
        return res.json();
    })
    .then((jsonRes) => {
        for (let i = 0; i < 20; i++) {
            $(`#card-title-${i}`).text(jsonRes[i]["title"]);
            $(`#card-text-${i}`).text(jsonRes[i]["body"]);
            $(`#user-${i}`).text(`Posted by User ID ${jsonRes[i]["userId"]}`);
        }
    })
}

// Call the makePosts function
makePosts();