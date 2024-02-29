function showLogOutAlert() {
    var token = $('input[name="__RequestVerificationToken"]').val();
    console.log(token);
    Swal.fire({
        title: 'Are you sure you want to log out?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, I want to log out!'
    }).then((result) => {
        if (result.isConfirmed) {
            $('form#logoutForm').submit();
            $.ajax({
                url: '/Identity/Account/Logout',
                type: 'POST',
                success: function (data) {
                   window.location.href = '/Identity/Account/Logout';
                },
                error: function (xhr, status, error) {
                    console.error("Logout failed:", error);
                }
            })
        }
    })
}


// DO NOT DELETE

//function showLogOutAlert() {
//    var token = $('input[name="__RequestVerificationToken"]').val();
//    console.log(token);
//    Swal.fire({
//        title: 'Are you sure you want to log out?',
//        icon: 'question',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, I want to log out!'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $('form#logoutForm').submit();
//        }
//    })
//}

// DO NOT DELETE