# this is a test case file created by group five members

import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By

class BalanceEnquiryTest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
        self.driver.get("https://demo.guru99.com/V4/manager/BalEnqInput.php")

    def test_balance_enquiry(self):
        driver = self.driver

        # Fill in form details
        driver.find_element(By.NAME, "accountno").send_keys("123456")

        # Submit the form
        driver.find_element(By.NAME, "AccSubmit").click()

        # Check if the balance is displayed
        balance = driver.find_element(By.XPATH, "//table//td[contains(text(), 'Balance')]/following-sibling::td").text
        self.assertTrue(balance.isnumeric())

    def tearDown(self):
        self.driver.close()

if __name__ == "__main__":
    unittest.main()
