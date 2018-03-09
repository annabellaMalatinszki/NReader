import React from 'react';
import { Link } from 'react-router';
import Home from './Home';
import About from './About';
import Missing from './Missing';
import '../styles/Page.scss';
 
class Page extends React.Component {
    constructor(props){
        super(props);
 
        this.getNavActions = this.getNavActions.bind(this);
        this.getNavAction = this.getNavAction.bind(this);
    }
 
    state = {
        sectionName: 'Home',
        activeAction: 0,
        activeComponent: <Home />
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
        var section = this.props.location.pathname.replace('/','');
        if(section == ''){ section = 'Home'; }
         this.setState(this.getNavAction(section, false));
    };
 
    render() {
        return(
            <div className="Page">
                <div>
                     <Link to="/Home" onClick={this.handleNavAction.bind(this,0)}>Home</Link> | 
                     <Link to="/About" onClick={this.handleNavAction.bind(this,1)}>About</Link> |
                     <Link to="/BadLink" onClick={this.handleNavAction.bind(this,-1)}>Bad Link</Link>
                </div>
                {this.state.activeComponent}                
            </div>
        );
    };
};
 
export default Page;