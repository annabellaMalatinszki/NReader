//import React from 'react';
//import { render } from 'react-dom';
//import { App } from './App';




class App extends React.Component {
    render() {
        return (
            <div className="App" >
                Hello, world! I am an App.
            </div>)
    }
}

ReactDOM.render( <App />, document.querySelector('#content'));