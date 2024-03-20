$(document).ready(function () {

    $('#TableLivros').DataTable();


    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $this.alert('close');
        })
    }, 3000)
});