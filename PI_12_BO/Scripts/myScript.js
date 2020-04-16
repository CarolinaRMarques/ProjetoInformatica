$(".btn").html(function (e) {
    console.log(this.innerHTML);
    switch (this.innerHTML) {
        case "Back to List":
            this.innerHTML = "<i class=\"fa fa-list\" aria-hidden=\"true\"></i>";
            break;
        case "Create New":
            this.innerHTML = "<i class=\"fa fa-plus\" ria-hidden=\"true\"></i>";
            break;
        case "Delete":
            this.innerHTML = "<i class=\"fa fa-trash-o\" aria-hidden=\"true\"></i>";
            break;
        case "Details":
            this.innerHTML = "<i class=\"fa fa-eye\" aria-hidden=\"true\"></i>";
            break;
        case "Edit":
            this.innerHTML = "<i class=\"fa fa-edit\" aria-hidden=\"true\"></i>";
            break;
        case "Link":
            this.innerHTML = "<i class=\"fa fa-link\" aria-hidden=\"true\"></i>";
            break;
        case "Log in":
            this.innerHTML = "<i class=\"fa fa-sign-in\" aria-hidden=\"true\"></i>";
            break;
        case "Logout":
            this.innerHTML = "<i class=\"fa fa-sign-out\" aria-hidden=\"true\"></i>";
            break;
        case "New user":
            this.innerHTML = "<i class=\"fa fa-user-plus\" aria-hidden=\"true\"></i>";
            break;
        case "Create":
        case "Save":
            this.innerHTML = "<i class=\"fa fa-save\" aria-hidden=\"true\"></i>";
            break;
        case "Remove":
            this.innerHTML = "<i class=\"fa fa-times text-danger\" aria-hidden=\"true\"></i>";
            break;
        case "Search":
            this.innerHTML = "<i class=\"fa fa-search\" aria-hidden=\"true\"></i>";
            break;
    }
});

$("h3").html(function (e) {
    console.log(this.innerHTML);
    if (this.innerText == "Are you sure you want to delete this?") {
        this.innerText = "Tem a certeza que petende apagar ?";
        this.classList.add("text-danger");
    }
});
