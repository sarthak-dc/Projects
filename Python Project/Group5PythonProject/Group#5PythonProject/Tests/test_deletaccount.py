# this is the test case file for the delete account page

import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By

class DeleteAccountTest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
        self.driver.get("https://demo.guru99.com/V4/manager/deleteAccountInput.php")

    def test_delete_account(self):
        driver = self.driver

        # Fill in form details
        driver.find_element(By.NAME, "accountno").send_keys("123456")

        # Submit the form
        driver.find_element(By.NAME, "AccSubmit").click()

        # Check if the account was successfully deleted
        success_message = driver.find_element(By.XPATH, "//table//p").text
        self.assertEqual(success_message, "Account Deleted Sucessfully")

    def tearDown(self):
        self.driver.close()

if __name__ == "__main__":
    unittest.main()
