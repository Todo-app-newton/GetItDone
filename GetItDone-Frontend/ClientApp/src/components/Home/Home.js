import React, { Component } from 'react';
import HomeImg from './homeimg.png';
import './Home.css';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
   
        };
    }

    render() {
       
        return (
            <div>
                <div className="HomeImg">
                    <img src={HomeImg} alt="HomeImg" className="firstImg" />
                </div>
            </div>
        );
    }
}