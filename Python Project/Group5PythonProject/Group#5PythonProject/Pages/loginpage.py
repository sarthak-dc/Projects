#
# This is the .py file allocated for the login page of the final project.
# date 14th december
#

from selenium.webdriver.common.by import By
class loginpage:
    #creating a constructor- called everytime an object is being created
    def __int__(self,driver):
        # the Objects we interact with.
        self.userID_textbox_name = "uid"
        self.password_texbox_name = "password"
        self.submit_button_name = "btnLogin"

        #action Methods or function
        def enter_userID(self, userID):
            self.driver.find_element(By.NAME,self.userID_textbox_name).clear()
            self.driver.find_element(By.NAME,self.userID_textbox_name).send_keys(userID)


        def enter_password(self, password):
            self.driver.find_element(By.NAME, self.password_textbox_name).clear()
            self.driver.find_element(By.NAME, self.password_textbox_name).send_keys(password)


        def click_submit(self):
            self.driver.find_element(By.NAME, self.submit_button_name).click()

