import React from 'react';
import './RoomInfo.css'
import {Button} from 'react-bootstrap'
import Room from './Room'
class RoomInfo extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            roomInfo : props.room,
            setPage : props.setPage
        }
    }

    render() {
        const room = this.state.roomInfo;
        const roomImg =require('../img/'+room.UrlImage);
        return (
            <div className="room-info">             
                <div className="logo">
                <div onClick={()=>this.state.setPage(<Room setPage={this.state.setPage} room={this.state.roomInfo}/>)} className="room-stat">
                    <p>{room.MinUsers}-{room.MaxUsers} participans</p>
                    <p>{room.Delay} mins.</p>
                    <p>{room.EscapeRate}%</p>
                </div>
                     <img src={roomImg}/>
                </div>
               
                <h3>{room.Name}</h3>
                <p>{room.Discription}</p>
                <Button onClick={()=>this.state.setPage(<Room key={room.Id} setPage={this.state.setPage} room={this.state.roomInfo}/>)} variant="outline-warning">BOOK NOW</Button>
            </div>
        )
    }
}

export default RoomInfo;