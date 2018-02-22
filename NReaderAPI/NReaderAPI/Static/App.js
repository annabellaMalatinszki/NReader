class View {

    constructor() {
        this.$newsItems = document.querySelector('#news-items');
        this.$newsfeed = document.querySelector('#newsfeed');
    }

}

class Controller {

    constructor(view) {
        Controller.GET = 'GET';
        Controller.POST = 'POST';

        this.view = view;

        // Bindings to the view should go here.

        this.load();
    }

    sendAjax(endpoint, method, params = null, onSuccess = null) {
        const scope = this;
        const req = new XMLHttpRequest();
        req.addEventListener("load", function (event) {
            onSuccess.call(scope, event);
        });
        req.open(method, endpoint);
        if (method === Controller.POST) {
            req.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        }
        req.send(params);
    }


}

const view = new View();

new Controller(view);