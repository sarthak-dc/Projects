# this is the edit customer class page created for the final project.
class EditCustomerPageElement:
    def __init__(self, driver):
        self.driver = driver
        self.customer_id_textbox_id = "cusid"
        self.submit_button_name = "AccSubmit"
        self.reset_button_name = "res"
        self.customer_name_textbox_id = "name"
        self.gender_male_radio_button_id = "gender"
        self.gender_female_radio_button_id = "gender"
        self.date_of_birth_textbox_id = "dob"
        self.address_textarea_id = "addr"
        self.city_textbox_id = "city"
        self.state_textbox_id = "state"
        self.pin_textbox_id = "pinno"
        self.mobile_number_textbox_id = "telephoneno"
        self.email_textbox_id = "emailid"
        self.password_textbox_id = "password"
        self.submit_button_name = "sub"

    def enter_customer_id(self, customer_id):
        self.driver.find_element_by_id(self.customer_id_textbox_id).send_keys(customer_id)

    def click_submit(self):
        self.driver.find_element_by_name(self.submit_button_name).click()

    def click_reset(self):
        self.driver.find_element_by_name(self.reset_button_name).click()

    def enter_customer_name(self, customer_name):
        self.driver.find_element_by_id(self.customer_name_textbox_id).clear()
        self.driver.find_element_by_id(self.customer_name_textbox_id).send_keys(customer_name)

    def select_gender(self, gender):
        if gender.lower() == "male":
            self.driver.find_element_by_id(self.gender_male_radio_button_id).click()
        elif gender.lower() == "female":
            self.driver.find_element_by_id(self.gender_female_radio_button_id).click()

    def enter_date_of_birth(self, date_of_birth):
        self.driver.find_element_by_id(self.date_of_birth_textbox_id).clear()
        self.driver.find_element_by_id(self.date_of_birth_textbox_id).send_keys(date_of_birth)

    def enter_address(self, address):
        self.driver.find_element_by_id(self.address_textarea_id).clear()
        self.driver.find_element_by_id(self.address_textarea_id).send_keys(address)

    def enter_city(self, city):
        self.driver.find_element_by_id(self.city_textbox_id)