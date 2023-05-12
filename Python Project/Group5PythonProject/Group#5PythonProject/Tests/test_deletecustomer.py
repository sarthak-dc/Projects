#this is the test case file for the delecustomer

#
#

from selenium import webdriver
from selenium.webdriver.common.by import By
import unittest

class DeleteCustomer(unittest.TestCase):
    def setUpClass(cls):
        cls.driver = webdriver.chrome()
        cls.driver.implicity_wait(20)
        cls.driver.maximize_window()

def test_delete_customer(self):
    self.driver.find_element_by_xpath("/html/body/div[3]/div/ul/li[4]/a").click()
    self.driver.find_element(By.NAME, "cusid").send_keys("74652")
    self.driver.find_element(By.NAME, "AccSub").click()



def tearDownClass(cls):
    cls.driver.close()
    cls.driver.quit()
    cls.print("Test Completed")






