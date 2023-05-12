
# this is the test case file for the edit customer
from selenium import webdriver
from selenium.webdriver.common.by import By
import unittest


class EditCustomer(unittest.TestCase):
    def setUpClass(cls):
        cls.driver = webdriver.chrome()
        cls.driver.implicity_wait(20)
        cls.driver.maximize_window()


def test_edit_customer(self):
    self.driver.find_element_by_xpath("/html/body/div[2]/div/div/ul/li[3]/a").click()
    self.driver.find_element(By.NAME, "cusid").send_key(" CXZV")
    self.driver.find_element(By.NAME, "AccSubmit").click()

def tearDownClass(cls):
    cls.driver.close()
    cls.driver.quit()
    cls.print("Test Completed")



