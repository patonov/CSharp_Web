import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  userform: FormGroup = new FormGroup({});
  submitted = false;

  constructor(private formBuilder: FormBuilder) {}

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

    if(this.userform.valid){
      console.log(this.userform.value);
    }
  }

}
