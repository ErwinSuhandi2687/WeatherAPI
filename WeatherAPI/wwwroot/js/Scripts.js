function loadCountry() {
        $.ajax({
            type: 'GET',
            url: "https://localhost:44387/api/weather/countries",
            dataType: 'json',
            success: function (data) {
                var obj = data.data;
                var html = '<option value="">-- Please Fill Country --</option>';
                var state = "";
                $.each(obj, function (index, value) {
                    if (state != value.state) {
                        state = value.state;
                        html += '<option value="' + value.countryCode + '">' + state + '</option>';
                    }                    
                });
                $('#Country').html(html);
            },
        });
}

$('#Country').on('change', function () {
    $.ajax({
        type: 'GET',
        url: "https://localhost:44387/api/weather/cities/" + this.value,
        dataType: 'json',
        success: function (data) {
            console.log(data);
            var obj = data.data;
            var html = '<option value="">-- Please Fill City --</option>';
            $.each(obj, function (index, value) {
                html += '<option value="' + value.cityName + '">' + value.cityName + '</option>';
            });
            $('#City').html(html);
        },
    });
});



$('#City').on('change', function () {
    var apiKey = "0076e0f54a0da9dfc7ee12638ecb80f3";
    var city = this.value;

    $.ajax({
        type: 'GET',
        url: "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey,
        dataType: 'json',
        success: function (result, status, xhr) {
            var table = $("<table><tr><th>Weather Description</th></tr>");
            table.append("<tr><td>City:</td><td>" + result["name"] + "</td></tr>");
            table.append("<tr><td>Country:</td><td>" + result["sys"]["country"] + "</td></tr>");
            table.append("<tr><td>Location (Longitude):</td><td>" + result["coord"]["lon"] + "</td></tr>");
            table.append("<tr><td>Location (Latitude):</td><td>" + result["coord"]["lat"] + "</td></tr>");
            table.append("<tr><td>Time:</td><td>" + result["timezone"] + "</td></tr>");
            table.append("<tr><td>Wind (Speed):</td><td>" + result["wind"]["speed"] + "</td></tr>");
            table.append("<tr><td>Wind (Deg):</td><td>" + result["wind"]["deg"] + "</td></tr>");
            table.append("<tr><td>Visibility:</td><td>" + result["visibility"] + "</td></tr>");
            table.append("<tr><td>Sky Conditions:</td><td>" + result["weather"][0]["description"] + "</td></tr>");

            $("#weatherDescription").html(table);

            $.ajax({
                type: 'GET',
                url: "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey + "&units=metric",
                dataType: 'json',
                success: function (result1, status1, xhr1) {
                    table.append("<tr><td>Temperature (In Celcius):</td><td>" + result1["main"]["temp"] + "°C</td></tr>")
                    $("#weatherDescription").html(table);

                    $.ajax({
                        type: 'GET',
                        url: "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey + "&units=imperial",
                        dataType: 'json',
                        success: function (result1, status1, xhr1) {
                            table.append("<tr><td>Temperature (In Fahrenheit):</td><td>" + result1["main"]["temp"] + "°C</td></tr>")
                            table.append("<tr><td>Dew Point:</td><td>" + result["weather"][0]["main"] + "</td></tr>");
                            table.append("<tr><td>Relative Humidity:</td><td>" + result["main"]["humidity"] + "</td></tr>");
                            table.append("<tr><td>Pressure:</td><td>" + result["main"]["pressure"] + "</td></tr>");

                            $("#weatherDescription").html(table);
                        },
                        error: function (xhr, status, error) {
                            alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
                        }
                    });
                },
                error: function (xhr1, status1, error1) {
                    alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
                }
            });
        },
        error: function (xhr, status, error) {
            alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
        }
    });
});