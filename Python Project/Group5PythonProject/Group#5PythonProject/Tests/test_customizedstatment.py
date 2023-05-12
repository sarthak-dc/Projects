import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By

class CustomisedStatementTest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
        self.driver.get("https://demo.guru99.com/V4/manager/CustomisedStatementInput.php")

    def test_customised_statement(self):
        driver = self.driver

        # Fill in form details
        driver.find_element(By.NAME, "accountno").send_keys("123456")
        driver.find_element(By.NAME, "fdate").send_keys("01/01/2020")
        driver.find_element(By.NAME, "tdate").send_keys("01/31/2020")
        driver.find_element(By.NAME, "ammountlowerlimit").send_keys("1000")
        driver.find_element(By.NAME, "numtransaction").send_keys("5")

        # Submit the form
        driver.find_element(By.NAME, "AccSubmit").click()

        # Check if the statement is displayed
        statement_table = driver.find_element(By.XPATH, "//table[@id='customers']")
        self.assertTrue(statement_table.is_displayed())

    def tearDown(self):
        self.driver.close()

if __name__ == "__main__":
    unittest.main()
