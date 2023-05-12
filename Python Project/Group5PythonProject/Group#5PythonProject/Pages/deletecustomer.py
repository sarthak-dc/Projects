# this is the class delete customer page created for the delete customer page.
#class
class DeleteCustomerPageElement:
    def __init__(self, driver):
        self.driver = driver
        self.customer_id_textbox_id = "cusid"
        self.submit_button_name = "AccSubmit"
        self.reset_button_name = "res"

    def enter_customer_id(self, customer_id):
        self.driver.find_element_by_id(self.customer_id_textbox_id).send_keys(customer_id)

    def click_submit(self):
        self.driver.find_element_by_name(self.submit_button_name).click()

    def click_reset(self):
        self.driver.find_element_by_name(self.reset_button_name).click()