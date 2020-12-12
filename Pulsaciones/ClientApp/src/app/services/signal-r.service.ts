import { HttpClient } from '@angular/common/http';
import { EventEmitter, Inject, Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Person } from '../models/person';
@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  signalReceived = new EventEmitter<Person>();
  baseUrl: string;

  constructor(
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
    this.buildConnection();
    this.startConnection();
  }


  private buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.baseUrl + 'signalHub')
      .build();
  }

  private startConnection = () => {
    this.hubConnection
      .start()
      .then(() => {
        console.log('Connection Started...');
        this.registerSignalEvents();
      })
      .catch(err => {
        console.log('Error while starting connection: ' + err);

        // if you get error try to start connection again after 3 seconds.
        setTimeout(function() {
          this.startConnection();
        }, 3000);
      });
  }

  private registerSignalEvents() {
    this.hubConnection.on('PersonaRegistrada', (data: Person) => {
      this.signalReceived.emit(data);
    });
  }
}
