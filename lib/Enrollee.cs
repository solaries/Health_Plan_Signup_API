public class Enrollee{

    public string payment_frequency { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email_address { get; set; }
    public string phone_number { get; set; }
    public int plan_id { get; set; }  
    public bool can_complete_profile { get; set; }  
    public Dependant[] dependants { get; set; }

}