#this is the test case file for the ministatement

import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By

class MiniStatementTest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
        self.driver.get("https://demo.guru99.com/V4/manager/Mini StatementInput.php")

    def test_mini_statement(self):
        driver = self.driver

        # Fill in form details
        driver.find_element(By.NAME, "accountno").send_keys("123456")

        # Submit the form
        driver.find_element(By.NAME, "AccSubmit").click()

        # Check if the mini statement is displayed
        statement_table = driver.find_element(By.XPATH, "//table[@id='customers']")
        self.assertTrue(statement_table.is_displayed())

    def tearDown(self):
        self.driver.close()

if __name__ == "__main__":
    unittest.main()
