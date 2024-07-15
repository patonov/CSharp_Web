import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ChatService } from '../chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent implements OnInit {
  @Output() closeChatEmitter = new EventEmitter();

  constructor(public chatService: ChatService) {}

  ngOnInit(): void {
    this.chatService.createChatConnection();
  }

  backToHome(){
    this.closeChatEmitter.emit();
  }
}
