$(document).on("click", ".delete-warn", function (e) {
    e.preventDefault();
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location = e.currentTarget.href;
        }
    });
});

$(document).ready(function () {
    $('.datatable').dataTable({
        autoWidth: true,
    });
});
