// Lab 3
// Sarthak Thukran
// 21st March, 2023
// Durham College


// User Class

class User {
    // getters and setters
    get FirstName() {
      return this.m_firstName;
    }
  
    set FirstName(first_name) {
      this.m_firstName = first_name;
    }
  
    get LastName() {
      return this.m_lastName;
    }
  
    set LastName(last_name) {
      this.m_lastName = last_name;
    }
  
    get EmailAddress() {
      return this.m_emailAddress;
    }
  
    set EmailAddress(email_address) {
      this.m_emailAddress = email_address;
    }
  
    get Password() {
      return this.m_password;
    }
  
    set Password(password) {
      this.m_password = password;
    }
  
    // constructor
    constructor(firstName = "", lastName = "", emailAddress = "", password = "") {
      this.FirstName = firstName;
      this.LastName = lastName;
      this.EmailAddress = emailAddress;
      this.Password = password;
    }
  
    // overridden toString() method
  
    toString() {
      return `First Name: ${this.FirstName} \nLast Name: ${this.LastName} \nEmail Address: ${this.EmailAddress}  \nPassword: ${this.Password}`;
    }
  }