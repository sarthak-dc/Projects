// Lab 2
// Sarthak Thukran
// 4th March, 2023
// Durham College


// This file is for the java script for the whole Lab 
function checkPage()
{
    //Changes product link to projects using DOM
    currentNode = document.getElementById( "products" );
    currentNode.innerHTML =`<li id ="products"><a href="products.html">
    <i class="fa-solid fa-border-all"></i> Products</a></li>`;

    // Finds the nav and sets it to the current node
    currentNode = document.getElementById("nav");
   // Creates the humanresources link to append
    var newNavLink = document.createElement("li");
    var newA = document.createElement("a");
    var newI=document.createElement("i");
    newA.setAttribute("id", "humanresources");
    newA.setAttribute("href", "humanresources.html");
    newI.setAttribute("class", "fas fa-user-tie");
    newA.textContent =" Human Resources";
    newA.prepend(newI);
    newNavLink.appendChild(newA);

   // Adds new human resoursces link to nav bar
    currentNode.insertBefore(newNavLink, currentNode.childNodes[4]);

    // Gets current url pathname to determine current page
    var path = window.location.pathname;
    var page = path.split("/").pop();

    // Builds the index page if the index page was opened
    if (page == "index.html")
    {
        indexPage();
    }

    // Builds the products/ projects page if the products page was opened
    else if (page == "products.html")
    {
        productsPage();
    }

    // Builds the services page if the services page was opened
    else if (page == "services.html")
    {
        servicesPage();
    }

    // Builds the about page if the about page was opened
    else if (page == "about.html")
    {
        aboutPage();
    }

    //Builds the contact page if the contact page was opened
    else if (page == "contact.html")
    {
        contactPage();
    }
    else if(page=="login.html"){
        loginpage();

    }
    else if(page="register.html"){
        RegisterPage();
    }
}

  (function () 
  {
     // Navigation bar for footer to display CopyRight sign and year at the bottom of the page.
  let DocumentBody = document.body;
  let Footer = document.createElement("footer");
  let FooterNavBar = `<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <div class="container-fluid">
  <a class="navbar-brand"><i class="far fa-copyright"></i>CopyRight 2023 </a> 
  </div>
  </nav>`;
  Footer.innerHTML = FooterNavBar;
  DocumentBody.appendChild(Footer);

    /**
     * 
     * This function is used to add or edit the existing things in the About Us Page.
     */
    function DisplayAboutPage()
    {
        console.log("About Us Page");

        let About1Content = document.getElementsByTagName("main")[0];
       
        let About2Content = document.getElementsByTagName("main")[1];

        let  About3Content = document.getElementsByTagName("main")[2];
        
        let About1Paragraph = document.createElement("p");
        let About2Paragraph = document.createElement("p");
        let About3Paragraph = document.createElement("p");

        About1Paragraph.setAttribute("id", "AboutParagraph");
        About1Paragraph.setAttribute("class", "mt-3");
        About1Paragraph.textContent = "I believe in working hard and playing hard.I'm a talented, dedicated individual who is passionate about what I do. Whether it's coding the latest and greatest software, or playing my favourite games, we all have a unique story to tell. Read on to learn more about my Wonderful world.";

        About2Paragraph.setAttribute("id", "About2Paragraph");
        About2Paragraph.setAttribute("class", "mt-3");
        About2Paragraph.textContent = "In our free time, you'll find me pursuing a variety of interests and hobbies. From traveling around the provinces, to playing on sports teams.These different passions keeps me busy. Whether it's competing in college sports games, or trying out a new recipe in the kitchen, there's never a dull moment when I'm around!My Favorite Lawn Tennis player is Roger Federer who retired from the game recently.";

        About3Paragraph.setAttribute("id", "About3Paragraph");
        About3Paragraph.setAttribute("class", "mt-3");
        About3Paragraph.textContent = "My Hobbies include playing Lawn tennis, spending time in the gym, surfing for new car variants online and building cars virtually on a simulator and lastly playing awesome games on my XBOX.I also own a BMW 330i that's why my favourite car brand is BMW.";

        About1Content.appendChild(About1Paragraph);
        About2Content.appendChild(About2Paragraph);
        About3Content.appendChild(About3Paragraph);

        document.getElementById("ProductsLink").innerHTML = "Products";

        
    }

    /**
     *
     * This function is used to add or edit the existing things in the Products Page.
     */
    function DisplayProductsPage()
    {
        console.log("Products Page");

        //step 1 get a reference to an entry point(s)
        let Products1Content = document.getElementsByTagName("main")[0];

        let Products2Content = document.getElementsByTagName("main")[1];

        let Products3Content = document.getElementsByTagName("main")[2];
       

        //step 2 create an element
        let Products1Paragraph = document.createElement("p");
        let Products2Paragraph = document.createElement("p");
        let Products3Paragraph = document.createElement("p");
        

        //step 3 configure new element
        Products1Paragraph.setAttribute("id", "Products1Paragraph");
        Products1Paragraph.setAttribute("class", "mt-3");
        Products1Paragraph.textContent = "Breaking Bad is a critically-acclaimed television series that follows the story of Walter White, a high school chemistry teacher turned methamphetamine manufacturer. As the series progresses, Walter's choices lead him down a dark path and the show explores themes of morality, family, and the American Dream. With incredible writing, memorable characters, and stunning cinematography, Breaking Bad is a must-watch for anyone who loves high-stakes drama and character-driven storytelling. The show's tight pacing and intense plot twists will keep you on the edge of your seat, making it one of the greatest television series of all time.";
        
        
        Products2Paragraph.setAttribute("id", "Products2Paragraph");
        Products2Paragraph.setAttribute("class", "mt-3");
        Products2Paragraph.textContent = "The Witcher is a fantasy drama television series created by Lauren Schmidt Hissrich for Netflix. It is based on the book series of the same name by Polish writer Andrzej Sapkowski. Set on a fictional, medieval-inspired landmass known as the Continent, The Witcher explores the legend of Geralt of Rivia, Yennefer of Vengerberg and Princess Ciri. It stars Henry Cavill, Anya Chalotra, and Freya Allan.";


        Products3Paragraph.setAttribute("id", "Products3Paragraph");
        Products3Paragraph.setAttribute("class", "mt-3");
        Products3Paragraph.textContent = "Top Gun: Maverick is a 2022 American action drama film directed by Joseph Kosinski and written by Ehren Kruger, Eric Warren Singer, and Christopher McQuarrie from stories by Peter Craig and Justin Marks. The film is a sequel to the 1986 film Top Gun. Tom Cruise reprises his starring role as the naval aviator Maverick. The film also stars Miles Teller, Jennifer Connelly, Jon Hamm, Glen Powell, Lewis Pullman, Ed Harris and Val Kilmer. In the film, Maverick confronts his past while training a group of younger Top Gun graduates, including the son of his deceased best friend, for a dangerous mission.";
        

        //step 4 add/insert new element
        Products1Content.appendChild(Products1Paragraph);
        Products2Content.appendChild(Products2Paragraph);
        Products3Content.appendChild(Products3Paragraph);



        document.getElementById("ProductsLink").innerHTML = "Products";

       
       
    }

    /**
     *
     * This function is used to add or edit the existing things in the Services Page.
     */
    function DisplayServicesPage()
    {
        console.log("Services Page");

        //step 1 get a reference to an entry point(s)
        let Services1Content = document.getElementsByTagName("main")[0];

        let Services2Content = document.getElementsByTagName("main")[1];

        let Services3Content = document.getElementsByTagName("main")[2];
        
        let Services4Content = document.getElementsByTagName("main")[3];

       

        //step 2 create an element
        let Services1Paragraph = document.createElement("p");
        let Services2Paragraph = document.createElement("p");
        let Services3Paragraph = document.createElement("p");
        let Services4Paragraph = document.createElement("p");
        

        //step 3 configure new element
        Services1Paragraph.setAttribute("id", "Services1Paragraph");
        Services1Paragraph.setAttribute("class", "mt-3");
        Services1Paragraph.textContent = "I offer professional web design services to help bring your ideas to life. With a keen eye for detail and a focus on user experience, I create stunning, functional websites that are optimized for both desktop and mobile devices. Whether you need a simple brochure website or a complex e-commerce platform, I have the skills and experience to make it happen. If you're looking for a web designer who truly cares about your success, look no further.";
        
        
        Services2Paragraph.setAttribute("id", "Services2Paragraph");
        Services2Paragraph.setAttribute("class", "mt-3");
        Services2Paragraph.textContent = "Need a custom software solution for your business? Look no further! I offer a wide range of custom programming services, including web application development, database design, and API integration. With a focus on quality and efficiency, I deliver solutions that are tailored to meet the unique needs of your business. Whether you're looking to automate a complex process or build a new software product from scratch, I have the skills and experience to make it happen.";


        Services3Paragraph.setAttribute("id", "Services3Paragraph");
        Services3Paragraph.setAttribute("class", "mt-3");
        Services3Paragraph.textContent = "I offer professional mobile development services to help bring your ideas to life on the go. Whether you're looking to build a native app for iOS or Android, or a cross-platform app using technologies such as React Native, I have the skills and experience to make it happen. With a focus on user experience and performance, I deliver high-quality mobile apps that are optimized for both smartphones and tablets. If you're looking for a mobile developer who truly cares about your success, look no further.";
        
        Services4Paragraph.setAttribute("id", "Services4Paragraph");
        Services4Paragraph.setAttribute("class", "mt-3");
        Services4Paragraph.textContent = "For More Info Please Refer to My Resume";
        
        //step 4 add/insert new element
        Services1Content.appendChild(Services1Paragraph);
        Services2Content.appendChild(Services2Paragraph);
        Services3Content.appendChild(Services3Paragraph);
        Services4Content.appendChild(Services4Paragraph);

        document.getElementById("ProductsLink").innerHTML = "Products";

        
    }

    /**
     *
     * This function is used to add or edit the existing things in the Home Page.
     */
    function DisplayHomePage()
    {

        console.log("Home Page");

        
        
        //step 1 get a reference to an entry point(s)
        let MainContent = document.getElementsByTagName("main")[0];
        let MainContent2 = document.getElementsByTagName("main")[0];
        let MainContent3 = document.getElementsByTagName("main")[0];

        //step 2 create an element
        let MainParagraph = document.createElement("p");
        let MainParagraph2 = document.createElement("p");
        let MainParagraph3 = document.createElement("p");

        //step 3 configure new element
        MainParagraph.setAttribute("id", "MainParagraph");
        MainParagraph.setAttribute("class", "mt-3");
        MainParagraph.textContent = "Welcome to My Site!";
        MainParagraph2.setAttribute("id", "MainParagraph2");
        MainParagraph2.setAttribute("class", "mt-3");
        MainParagraph2.textContent = "Discover the beauty of nature and immerse yourself in breathtaking landscapes with our stunning collection of outdoor scenes. The mission is to bring the great outdoors to you, and to provide a window into the Future for all to see.";
        MainParagraph3.setAttribute("id", "MainParagraph3");
        MainParagraph3.setAttribute("class", "mt-3");
        MainParagraph3.textContent = "So, sit back, relax, and explore our world of Techs. You will learn more about me as you move forward.";

        //step 4 add/insert new element
        MainContent.appendChild(MainParagraph);
        MainContent2.appendChild(MainParagraph2);
        MainContent3.appendChild(MainParagraph3);
       
        let AboutUsButton = document.getElementById("AboutUsButton");
        AboutUsButton.addEventListener("click", function()
        {
            // redirect to about page
            location.href = "about.html";
        });

        document.getElementById("ProductsLink").innerHTML = "Products";

    }

    /**
     *
     * This function is used to add or edit the existing things in the Contact Page.
     */
    function DisplayContactPage()
    {
        console.log("Contact Us Page");

        let sendButton = document.getElementById("sendButton");
        let subscribeCheckBox = document.getElementById("subscribeCheckBox");
     // Send button Event handler
        
     sendButton.addEventListener("click", function(event)
        {
            event.preventDefault(); // for Debugging
            if(subscribeCheckBox.checked)
            {
                let contact = new Contact(fullName.value, contactNumber.value, emailAddress.value);
                console.log(contact.toString());
               
            }

            setTimeout(function()
            {
                location.href = "index.html";
            }, 3000);
        });

        

        document.getElementById("ProductsLink").innerHTML = "Products";

    }

    /**
     *
     * This function is used to add or edit the existing things in the Contact-List Page.
     */
    function DisplayContactListPage()
    {
        console.log("Contact List Page");

        if(localStorage.length > 0) // check if localStorage has something in it
        {
            let contactList = document.getElementById("contactList");

            let data = "";

            let keys = Object.keys(localStorage);

            let index = 1;

            //for every key in the keys collection loop
            for(const key of keys)
            {
                let contactData = localStorage.getItem(key); // retrieve contact data from localstorage

                let contact = new Contact(); // creates an empty Contact object
                contact.deserialize(contactData);

                data += `<tr>
                <th scope="row" class="text-center">${index}</th>
                <td>${contact.FullName}</td>
                <td>${contact.ContactNumber}</td>
                <td>${contact.EmailAddress}</td>
                <td></td>
                <td></td>
                </tr>
                `;

                index++;
            }

            contactList.innerHTML = data;
        }
        document.getElementById("ProductsLink").innerHTML = "Products";

        
    }

    
    /**
   * The DisplayLoginPage() function is used to display the username on the Navbar when the login button is clicked.
   */
    function DisplayLoginPage() {
        
        $(document).ready(function () {
          // When the login button is clicked,
          $("#loginButton").click(function () {
            // Create variables to get the values
            let usernameValue = $("#userName").val();
            let passwordValue = $("#password").val();
    
            // Check if the input value is empty or not
            if (usernameValue.length == "" || passwordValue.length == "") {
              return false;
            }
    
            // If the input value are not empty,
            else {
              /**
               * Add another link to Navbar between Contact Us link and Log in link.
               */
              // create an element(s) to insert
              let HRList1 = document.createElement("li");
              let HRLink1 = document.createElement("a");
              let HRIcon1 = document.createElement("i");
    
              // configure the new element
              HRLink1.setAttribute("class", "nav-link");
              HRIcon1.setAttribute("class", "fa-solid fa-user ");
              let HRNode1 = document.createTextNode($("#userName").val());
              HRLink1.setAttribute("href", "#");
    
              // Add / Insert the new element
              HRLink1.appendChild(HRIcon1);
              HRLink1.appendChild(HRNode1);
              HRList1.appendChild(HRLink1);
              //get an entry point(s) reference
              let list = document.getElementById("myList");
              list.insertBefore(HRList1, list.childNodes[13]);
    
              return false;
            }
          });
        });
      }
    
      /**
       * The DisplayRegisterPage() function used to validate the first name, last name, email address, password and
       * to check the values of confirm password and the register button. It also shows the inputs in the console.
       */
    
        function DisplayregisterPage() {
        $(document).ready(function () {
          // Validate FirstName
          $("#ErrorMessage").hide();
          let firstNameError = true;
          $("#FirstName").keyup(function () {
            validateFirstname();
          });
    
          function validateFirstname() {
            // Create variable to get the input value
            let firstnameValue = $("#FirstName").val();
    
            // Check if the input is empty or not
            if (firstnameValue.length == "") {
              // Show the error message
              $("#ErrorMessage").show();
              firstNameError = false;
              return false;
            }
    
            // Check the minimum length is 2 or not
            else if (firstnameValue.length < 2) {
              // Show the error message
              $("#ErrorMessage").show();
              $("#ErrorMessage").html("Length of firstname must be greater than 2");
              firstNameError = false;
              return false;
            }
    
            // Hide the error message
            else {
              $("#ErrorMessage").hide();
            }
          }
    
          // Validate LastName
          $("#ErrorMessage").hide();
          let lastNameError = true;
          $("#LastName").keyup(function () {
            validateLastName();
          });
    
          function validateLastName() {
            // Create variable to get the input value
            let lastNameValue = $("#LastName").val();
    
            // Check if the input value is empty or not
            if (lastNameValue.length == "") {
              // Show the error message
              $("#ErrorMessage").show();
              lastNameError = false;
              return false;
            }
    
            // Check the length of the input value
            else if (lastNameValue.length < 2) {
              // Show the error message
              $("#ErrorMessage").show();
              $("#ErrorMessage").html("Length of lastname must be greater than 2");
              lastNameError = false;
              return false;
            } else {
              // Hide the error message
              $("#ErrorMessage").hide();
            }
          }
    
          // Validate Email
          $("#ErrorMessage").hide();
          let emailError = true;
          $("#emailAddress").keyup(function () {
            validateEmail();
          });
          function validateEmail() {
            // Create variable to get input value
            let emailValue = $("#emailAddress").val();
    
            // Check the Regex for email
            let regex =
              /^([_\-\.0-9a-zA-Z]+)@([_\-\.0-9a-zA-Z]+)\.([a-zA-Z]){2,7}$/;
    
            // Check the input value is empty or not
            if (emailValue.length == "") {
              // Show the error message
              $("#ErrorMessage").show();
              emailError = false;
              return false;
            }
    
            // Check the regex
            else if (!regex.test(emailValue)) {
              // Show rhe error message
              $("#ErrorMessage").show();
              $("#ErrorMessage").html("Email Address is Invalid.");
    
              emailError = false;
              return false;
            } else if (regex.test(emailValue)) {
              $("#ErrorMessage").hide();
            }
          }
    
          //Validate Password
          $("#ErrorMessage").hide();
          let passwordError = true;
          $("#password").keyup(function () {
            validatePassword();
          });
          function validatePassword() {
            // Create variable to get input value
            let passwordValue = $("#password").val();
    
            // Check the length of the password
            if (passwordValue.length == "") {
              // Show the error message
              $("#ErrorMessage").show();
              passwordError = false;
              return false;
            }
    
            // Check the length is atleast 6
            if (passwordValue.length < 6) {
              // Show the error message
              $("#ErrorMessage").show();
              $("#ErrorMessage").html(
                "Length of your password must be atleast 6 characters."
              );
              passwordError = false;
              return false;
            } else {
              // Hide the error message
              $("#ErrorMessage").hide();
            }
          }
    
          // Validate Confirm Password
          $("#ErrorMessage").hide();
          let confirmPasswordError = true;
          $("#confirmPassword").keyup(function () {
            validateConfirmPassword();
          });
          function validateConfirmPassword() {
            // Create variable to get input value
            let confirmPasswordValue = $("#confirmPassword").val();
            let passwordValue = $("#password").val();
    
            // Check if the confirm password is same as password or not
            if (passwordValue != confirmPasswordValue) {
              // If not, show an error message
              $("#ErrorMessage").show();
              $("#ErrorMessage").html("Password and Confirm Password didn't Match");
              confirmPasswordError = false;
              return false;
            } else {
              // hide the error message
              $("#ErrorMessage").hide();
            }
          }
    
          // Submit button
          $("#logibButton").click(function () {
            validateFirstname();
            validateLastName();
            validatePassword();
            validateConfirmPassword();
            validateEmail();
    
            // Check for the errors
            if (
              firstNameError == true &&
              lastNameError == true &&
              passwordError == true &&
              confirmPasswordError == true &&
              emailError == true
            ) {
              return true;
            } else {
              // Create a new instance of the User Class
              let user = new User(
                $("#FirstName").val(),
                $("#LastName").val(),
                $("#emailAddress").val(),
                $("#password").val()
              );
              // Display it in the console
              console.log(user.toString());
    
              // Default Form Behaviour
              document.getElementById("FirstName").value.remove();
              document.getElementById("LastName").value.remove();
              document.getElementById("emailAddress").value.remove();
              document.getElementById("password").value.remove();
              return false;
            }
          });
        });
      }
    // Named function
    function Start()
    {
        console.log("App Started!!");
        

        switch (document.title) 
        {
          case "Home":
            DisplayHomePage();
            break;
          case "Contact Us":
            DisplayContactPage();
            break;
          case "Contact-List":
            DisplayContactListPage();
            break;
          case "About Us":
            DisplayAboutPage();
            break;
          case "My Products":
            DisplayProductsPage();
            break;
          case "Our Services":
            DisplayServicesPage();
            break;
        }

        
    }
    window.addEventListener("load", Start);
})();