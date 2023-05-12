// Lab 3
// Sarthak Thukran
// 21st March, 2023
// Durham College


class Contact
{
    // instance variables

    // public properties (getters / setters)
    get FullName()
    {
        return this.m_fullName;
    }

    set FullName(fullName)
    {
        this.m_fullName = fullName;
    }

    get ContactNumber()
    {
        return this.m_contactNumber;
    }

    set ContactNumber(contactNumber)
    {
        this.m_contactNumber = contactNumber;
    }

    get EmailAddress()
    {
        return this.m_emailAddress;
    }

    set EmailAddress(emailAddress)
    {
        this.m_emailAddress = emailAddress;
    }

    // constructor
    constructor(fullName = "", contactNumber = "", emailAddress = "") // default string parameter
    {
        this.FullName = fullName;
        this.ContactNumber = contactNumber;
        this.EmailAddress = emailAddress;
    }

    // public methods
    serialize()
    {
        if(this.FullName !== "" && this.ContactNumber !== "" && this.EmailAddress !== "")
        {
            return `${this.FullName},${this.ContactNumber},${this.EmailAddress}`;
        }
        console.error("One or more properties of the contact object are missing or empty");
        return null;
    }

    deserialize(data) // assume that the data object is a comma-separated list of properties
    {
        let propertyArray = data.split(",");
        this.FullName = propertyArray[0];
        this.ContactNumber = propertyArray[1];
        this.EmailAddress = propertyArray[2];
    }

    // overridden methods
    toString()
    {
        return `Full Name: ${this.FullName}\nContact Number: ${this.ContactNumber}\nEmail Address: ${this.EmailAddress}`;
    }
}