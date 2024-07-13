import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChatService } from '../chat.service';
import { error } from 'console';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  userform: FormGroup = new FormGroup({});
  submitted = false;
  apiErrorMessages: string[] = [];
  openChat = false;

  constructor(private formBuilder: FormBuilder, private chatService: ChatService) {}

  ngOnInit(): void {  
    this.initializeForm();
  }

  initializeForm(){
    this.userform = this.formBuilder.group({
      name: ['', Validators.required, Validators.minLength(3), Validators.maxLength(15)]
    })
  }

  submitForm(){
    this.submitted = true;
    this.apiErrorMessages = [];

    if(this.userform.valid){
      this.chatService.registerUser(this.userform.value).subscribe({
        next: () => {
          this.openChat = true;
        },
        error: error => {
          if(typeof (error.error) !== 'object'){
            this.apiErrorMessages.push(error.error);
          }
        }
        })
    }
  }

}
