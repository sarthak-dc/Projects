# This is the test for new customers
#december 8th

from selenium import webdriver
from selenium.webdriver.common.by import By
import unittest

from Pages.loginpage import loginpage


class NewCustomer(unittest.TestCase):
    def setUpClass(cls):
        cls.driver = webdriver.Chrome()
        cls.driver.implicity_wait(20)
        cls.driver.maximize_window()


    def test_login_valid(self):
        driver= self.driver
        #creating a object of logging page and pass the instance of driver in it.
        self.driver.get("https://demo.guru99.com/V4/")

        # self.driver.find_element_by_xpath("/html/body/form/table/tbody/tr[1]/td[2]/input").send_keys("mngr462738")
        # self.driver.find_element_by_xpath("/html/body/form/table/tbody/tr[2]/td[2]/input").send_keys("jyvYtUp")
        # self.driver.find_element_by_xpath("/html/body/form/table/tbody/tr[3]/td[2]/input[1]").click()
        login = loginpage(driver)
        login.enter_userID("mngr462738")
        login.enter_password("jyvYtUp")
        login.click_submit()
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[4]/td[2]/input").send_keys("lionel")
        self.driver.find_element(By.NAME, "rad1").click()
        self.driver.find_element(By.ID, "dob").click()
        self.driver.find_element(By.ID, "dob").send_keys("2022-12-14")
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[7]/td[2]/textarea").send_keys("DownTown")
        self.driver.find_elemen_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[8]/td[2]/input").send_keys("Toronto")
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[9]/td[2]/input").send_keys("Ontario")
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[9]/td[2]/input").send_keys("123456")
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[11]/td[2]/input").send_keys("52949300361")
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[12]/td[2]/input").send_keys("6gawd@gmail.com")
        self.driver.find_element_by_xpath("/html/body/table/tbody/tr/td/table/tbody/tr[13]/td[2]/input").send_keys("trashcanenjoyer")
        self.driver.find_element(By.NAME, "sub").click()



def tearDownClass(cls):
    cls.driver.close()
    cls.driver.quit()
    cls.print("Test Completed")











