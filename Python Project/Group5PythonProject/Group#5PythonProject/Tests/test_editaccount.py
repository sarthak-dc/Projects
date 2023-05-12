# this is the edit account file test case
import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By

class EditAccountTest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
        self.driver.get("https://demo.guru99.com/V4/manager/editAccount.php")

    def test_edit_account(self):
        driver = self.driver

        # Fill in form details
        driver.find_element(By.NAME, "accountno").send_keys("123456")
        driver.find_element(By.NAME, "fname").send_keys("John")
        driver.find_element(By.NAME, "lname").send_keys("Smith")
        driver.find_element(By.NAME, "email").send_keys("john.smith@example.com")
        driver.find_element(By.NAME, "addr").send_keys("123 Main Street")
        driver.find_element(By.NAME, "telephoneno").send_keys("123-456-7890")

        # Submit the form
        driver.find_element(By.NAME, "AccSubmit").click()

        # Check if the account was successfully edited
        success_message = driver.find_element(By.XPATH, "//table//p").text
        self.assertEqual(success_message, "Account Generated Successfully!!!")

    def tearDown(self):
        self.driver.close()

if __name__ == "__main__":
    unittest.main()
