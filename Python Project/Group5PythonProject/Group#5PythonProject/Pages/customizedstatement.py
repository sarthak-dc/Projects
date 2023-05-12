#this is the custermized page which was created for the final project.
#Date: 5th december 2022

#class
class CustomisedStatementPageElement:
    def __init__(self, driver):
        self.driver = driver
        self.account_number_textbox_id = "accountno"
        self.from_date_textbox_id = "fdate"
        self.to_date_textbox_id = "tdate"
        self.minimum_transaction_value_textbox_id = "ammountlowerlimit"
        self.number_of_transactions_textbox_id = "numtransaction"
        self.submit_button_name = "AccSubmit"
        self.reset_button_name = "res"

    def enter_account_number(self, account_number):
        self.driver.find_element_by_id(self.account_number_textbox_id).send_keys(account_number)

    def enter_from_date(self, from_date):
        self.driver.find_element_by_id(self.from_date_textbox_id).send_keys(from_date)

    def enter_to_date(self, to_date):
        self.driver.find_element_by_id(self.to_date_textbox_id).send_keys(to_date)

    def enter_minimum_transaction_value(self, minimum_transaction_value):
        self.driver.find_element_by_id(self.minimum_transaction_value_textbox_id).send_keys(minimum_transaction_value)

    def enter_number_of_transactions(self, number_of_transactions):
        self.driver.find_element_by_id(self.number_of_transactions_textbox_id).send_keys(number_of_transactions)

    def click_submit(self):
        self.driver.find_element_by_name(self.submit_button_name).click()
