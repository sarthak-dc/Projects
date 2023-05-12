# this is the test case file for the new account file

import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By

class AddAccountTest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
        self.driver.get("https://demo.guru99.com/V4/manager/addAccount.php")

    def test_add_account(self):
        driver = self.driver

        # Fill in form details
        driver.find_element(By.NAME, "cusid").send_keys("123456")
        driver.find_element(By.NAME, "inideposit").send_keys("1000")

        # Submit the form
        driver.find_element(By.NAME, "button2").click()

        # Check if the account was successfully added
        success_message = driver.find_element(By.XPATH, "//table//p").text
        self.assertEqual(success_message, "Account Generated Successfully!!!")

    def tearDown(self):
        self.driver.close()



