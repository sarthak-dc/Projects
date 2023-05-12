# this is the class file created for deleted account page
#class
class DeleteAccountPageElement:
    def __init__(self, driver):
        self.driver = driver
        self.account_number_textbox_id = "accountno"
        self.submit_button_name = "AccSubmit"
        self.reset_button_name = "res"

    def enter_account_number(self, account_number):
        self.driver.find_element_by_id(self.account_number_textbox_id).send_keys(account_number)

    def click_submit(self):
        self.driver.find_element_by_name(self.submit_button_name).click()

    def click_reset(self):
        self.driver.find_element_by_name(self.reset_button_name).click()