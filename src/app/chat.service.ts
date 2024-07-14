import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment';
import { User } from './models/User';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  myName: string = '';

  constructor(private httpClient: HttpClient) { }

  registerUser(user: User) {
    return this.httpClient.post('${environment.apiUrl}api/chat/register-user', user, {responseType: 'text'});
  }
}
