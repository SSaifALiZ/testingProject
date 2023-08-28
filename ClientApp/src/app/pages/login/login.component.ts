import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BridgeModel } from 'src/app/BridgeModel';
import { BridgeApiService } from 'src/app/services/bridgeapi.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  bm: BridgeModel = new BridgeModel();

  constructor(
    private formBulider: FormBuilder,
    private bridgeApiService: BridgeApiService
  ) {}
  ngOnInit() {
    this.loginForm = this.formBulider.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      authType: ['1'],
    });
  }
  submit() {
    if (this.loginForm.valid) {
      if (!this?.loginForm?.value?.email.includes('@')) {
        this.loginForm.value.email =
          this?.loginForm?.value?.email + '@tcs.com.pk';
      }
      this.bm.actionName = 'getauth';
      this.bm.param =
        'email=' +
        this?.loginForm?.value?.email +
        '&password=' +
        this?.loginForm?.value?.password +
        '&authType=' +
        this?.loginForm?.value?.authType;
      this.bm.data = [];
      this?.bridgeApiService
        ?.authenticate(this?.bm)
        ?.subscribe((response) => console.log('response:', response));
    }
  }
}
