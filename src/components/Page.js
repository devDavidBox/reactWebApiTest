import React from 'react';
import { Link } from 'react-router-dom';
import Home from './Home';
import About from './About';
import Missing from './Missing';
import ConceptComponent from './ConceptComponent';
import '../styles/Page.scss';
import 'whatwg-fetch'
import Concept from '../models/Concept';

const baseUrl = "http://localhost:50757"
 
class Page extends React.Component {
    constructor(props){
        super(props);
 
        this.getNavActions = this.getNavActions.bind(this);
        this.getNavAction = this.getNavAction.bind(this);
    }
 
    state = {
        sectionName: 'Home',
        activeAction: 0,
        activeComponent: <Home />,
        concepts: []
    }; 
 
    handleNavAction(action) {
        try {
            var act = this.getNavAction(action);
            if(!act){ 
                act = { activeAction: -1, sectionName: 'Missing', activeComponent: <Missing /> };
            }
            if(this.state.sectionName === act.sectionName) { return; }
            this.setState(act);
        } catch(ex){
 
        }
    };
 
    getNavActions() {
        return [
            { activeAction: 0, sectionName: 'Home', activeComponent: <Home /> },
            { activeAction: 1, sectionName: 'About', activeComponent: <About /> },
        ];
    };   
 
    getNavAction(value, useAction = true) {
        var action = null;
        if(useAction){
            action = this.getNavActions().find(x => x.activeAction == value);
        }else {
            action = this.getNavActions().find(x => x.sectionName === value);
        }
 
        if(!action) {
            action = {activeAction: -1, sectionName: value, activeComponent: <Missing />};
        }
 
        return action;
    };
 
    componentWillMount() {
        let targetUrl = `${baseUrl}/api/Concepts`;
        fetch(targetUrl)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            console.log(data);
            for (let concept of data) {
                console.log(concept);
            }

            console.log(this.state.sectionName);
            this.setState({concepts: data});
        })

        var section = this.props.location.pathname.replace('/','');
        if(section == ''){ section = 'Home'; }
         this.setState(this.getNavAction(section, false));
    };
 
    render() {

        var concepts = this.state.concepts.map((item, i) => {
          <ConceptComponent />  
        });

        console.log(concepts);

        return(

            <div class="container">
                <div className="Page">
                    <div>
                        <Link to="/Home" onClick={this.handleNavAction.bind(this,0)}>Home</Link> | 
                        <Link to="/About" onClick={this.handleNavAction.bind(this,1)}>About</Link>
                    </div>
                    {this.state.activeComponent}                
                </div>
            </div>

        );
    };
};
 
export default Page;