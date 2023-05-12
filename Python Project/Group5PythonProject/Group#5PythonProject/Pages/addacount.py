

#this is the addaccount page created

#class
class AddAccountPageElement:
    def __init__(self, driver):
        self.driver = driver
        self.customer_id_textbox_id = "cusid"
        self.account_type_dropdown_id = "selaccount"
        self.initial_deposit_textbox_id = "inideposit"
        self.submit_button_name = "button2"
        self.reset_button_name = "reset"

    def enter_customer_id(self, customer_id):
        self.driver.find_element_by_id(self.customer_id_textbox_id).send_keys(customer_id)

    def select_account_type(self, account_type):
        dropdown = self.driver.find_element_by_id(self.account_type_dropdown_id)
        dropdown.find_element_by_xpath("//option[text() = '" + account_type + "']").click()

    def enter_initial_deposit(self, initial_deposit):
        self.driver.find_element_by_id(self.initial_deposit_textbox_id).send_keys(initial_deposit)

    def click_submit(self):
        self.driver.find_element_by_name(self.submit_button_name).click()

    def click_reset(self):
        self.driver.find_element_by_name(self.reset_button_name).click()
