{
    function seenMessage(id) {
        fetch('https://localhost:44357/panel/SeenMessage/' + id, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
        })
            .then(response => response.json())
            .then(result => {
                toastr.info(result, "Bilgi")
                $('#seenCheckbox').prop("checked", true);
                $('#buttonn').addClass("disabled");
            })
            .catch(error => {
                toastr.error(error, "Hata")
            });
    }
    
   
}