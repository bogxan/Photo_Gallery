import {Component} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthenticationService} from "../authentication.service";
import {take} from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  form: FormGroup;

  constructor(
    private readonly authService: AuthenticationService
  ) {
    this.form = new FormGroup({
      'email': new FormControl('admin@gmail.com', [Validators.required, Validators.email]),
      'password': new FormControl('123456', Validators.required)
    });
  }

  onLoginClick() {
    if (this.form.valid) {
      const { email, password } = this.form.value;
      this.authService.login(email, password, 'admin').pipe(take(1)).subscribe();
    }
  }

  onRegistrationClick(){
    if (this.form.valid) {
      const { email, password } = this.form.value;
      this.authService.registration(email, password).pipe(take(1)).subscribe();
    }
  }
}
