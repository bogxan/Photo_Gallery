import {NgModule} from "@angular/core";
import {SharedModule} from "../shared.module";
import {LoginComponent} from "./login/login.component";
import {AuthenticationComponent} from "./authentication.component";
import {AuthenticationService} from "./authentication.service";

@NgModule({
  declarations: [
    LoginComponent,
    AuthenticationComponent
  ],
  imports: [
    SharedModule,
  ],
  providers: [
    AuthenticationService
  ],
  exports: [AuthenticationComponent]
})
export class AuthenticationModule { }
