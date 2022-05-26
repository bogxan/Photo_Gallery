import {Injectable} from "@angular/core";
import {CanActivate, Router} from "@angular/router";
import {AuthenticationService} from "../../authentication/authentication.service";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(public authService: AuthenticationService, public router: Router) {}
  canActivate(): boolean {
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
