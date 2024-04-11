function CheckName() {
    let Id = $("#Id").val();
    $.ajax({
        url: "https://apis.gometa.org/cedulas/" + Id,
        method: "GET",
        datatype: "json",
        success: function (response)
        {
            $("#Name").val(response.nombre)
        },
        error: function (response) {

        }
    })
}