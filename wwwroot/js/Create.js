$("#SaveData").click(function () {
    var response = validate();
    if (response == false) {
        return false;
    }
    else
    {
        let confirmation = confirm('Are you Sure!');
        if (confirmation == true) {
            var name = $("#Name").val();
            var city = $("#City").val();
            $.ajax({
                type: "post",
                url: "/employee/create/",
                data: {
                    "name": Name,
                    "city": City,
                },
                success: function (response) {
                    window.location.href = "/employee/Index";
                },
               
            });
        }
        else {
            return false;
        }
    }
});
function validate() {
    var IsActive = true;
    var Name = $("#Name").val();
    var City = $("#City").val();
    if (Name == "") {
        $("#NameError").html("* Name can't be blank");
        IsActive = false;
    }
    else {
        $("#NameError").html('');
        IsActive = true
    }
    if (City == "") {
        $("#CityError").html("* City can't be blank");
        IsActive = false;
    }
    else {
        $("#CityError").html('');
        IsActive = true
    }
    if (IsActive == true) {
        return true;
    }
    else {
        return false;
    }
};


