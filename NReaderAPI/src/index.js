import React from 'react';
import ReactDOM from 'react-dom';
import Page from './components/Page';
import Missing from './components/Missing';
import { Router, Route, hashHistory } from 'react-router';
 
window.React = React;
                 
ReactDOM.render(
    <Router history={hashHistory}>
        <Route path="/" component={Page} />
            <Route path="Home" component={Page} />
            <Route path="About" component={Page} />
            <Route path="*" component={Missing} />
    </Router>,
    document.getElementById('react-container')
);