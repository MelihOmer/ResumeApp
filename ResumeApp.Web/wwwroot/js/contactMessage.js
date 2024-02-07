{
    $(document).ready(function () {
        const div = document.getElementById('messageCount');
        fetch('https://localhost:44357/panel/messageCount', {
            method: 'GET'
        })
            .then(response => response.json())
            .then(result => {

                div.innerHTML = result;
            });
        $.ajax({
            type: "GET",
            url: `https://localhost:44357/Personel/GetContacts`,
            dataType: "json",
            cache: "false",
            success: function (data) {

                if (data != null) {
                    const container = document.getElementById('container');
                    container.innerHTML = '';
                    data.forEach(item => {
                        const htmlCode = `<a class="dropdown-item d-flex align-items-center" href="/panel/getContactMessageDetails/${item.id}">
                                                    <div class="font-weight-bold">
                                                        <div class="text-truncate">${item.message}</div>
                                                        <div class="small text-gray-500">${item.fullname} </div>
                                                    </div>
                                                </a>`;
                        container.insertAdjacentHTML('beforeend', htmlCode);
                    });
                }
            },
            error: function (xhr) {
                console.error('Mesaj Getirmede Hata : ' + xhr.status);
            }
        })
    })
    $('#messagesDropdown').click(function () {
        const div = document.getElementById('messageCount');
        fetch('https://localhost:44357/panel/messageCount', {
            method: 'GET'
        })
            .then(response => response.json())
            .then(result => {

                div.innerHTML = result;
            });
        $.ajax({
            type: "GET",
            url: `https://localhost:44357/Personel/GetContacts`,
            dataType: "json",
            cache: "false",
            success: function (data) {
                if (data != null) {
                    const container = document.getElementById('container');
                    container.innerHTML = '';
                    data.forEach(item => {
                        const htmlCode = `<a class="dropdown-item d-flex align-items-center" href="/panel/getContactMessageDetails/${item.id}">
                                                    <div class="font-weight-bold">
                                                        <div class="text-truncate">${item.message}</div>
                                                        <div class="small text-gray-500">${item.fullname} </div>
                                                    </div>
                                                </a>`;
                        container.insertAdjacentHTML('beforeend', htmlCode);
                    });
                }
            },
            error: function (xhr) {
                console.error('Mesaj Getirmede Hata : ' + xhr.status);

            }
        })
    })

}