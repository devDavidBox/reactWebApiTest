import React from 'react';
import ReactDOM from 'react-dom';
import Page from './components/Page';
import Missing from './components/Missing';
import { Router, Route, HashRouter } from 'react-router-dom';
 
window.React = React;
                 
ReactDOM.render(
    <HashRouter>
        <div>
            <Route path="/" component={Page} />
            <Route path="Home" component={Page} />
            <Route path="About" component={Page} />
            {/* <Route path="*" component={Missing} /> */}
        </div>
    </HashRouter>,
    document.getElementById('react-container')
);