function UiViewModel() {
    //Vars
    this.headerText = "Welcome to Knockout Tutorial",
    this.postText = ko.observable("");
    this.titleText = ko.observable("");
    this.author = ko.observable("");

    //Observables
    this.blogPosts = ko.observableArray([{ Title: "No Data Yet!", Body: "Click on the button to load data from the server" }]);

    //Functions
    this.getPosts = function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: "/api/BlogPost",
            data: null,
            contentType: "application/json",
            success: function (data) {
                self.blogPosts(data);
            },
            error: function () {
                alert("Error in loading data");
            }
        });
    },
    
    this.savePost = function () {
        var self = this;
        $.ajax({
            type: "POST",
            url: "/api/BlogPost",
            data: JSON.stringify({ Title: self.titleText(), Body: this.postText(), author: this.author(), PostedDate: new Date() }),
            contentType: "application/json",
            success: function (data) {
                if (data)
                    alert("Saved");
            },
            error: function () {
                alert("Error in loading data");
            }
        });
    }
}