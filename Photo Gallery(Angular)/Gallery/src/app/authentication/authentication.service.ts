import {Injectable} from "@angular/core";
import {AuthenticationApiService} from "../api/authentication-api.service";
import {Observable} from "rxjs";
import {map, tap} from "rxjs/operators";
import {BrowserLocalStorage} from "../shared/storage/local-storage";
import {Router} from "@angular/router";

@Injectable()
export class AuthenticationService {
  constructor(
    private readonly authService: AuthenticationApiService,
    private readonly localStorage: BrowserLocalStorage,
    private readonly router: Router
  ) {
  }

  registration(email: string, password: string){
    return this.authService.registration(email, password);
    this.router.navigate(['/authentication'])
  }

  login(email: string, password: string, role: string): Observable<string> {
    return this.authService.login(email, password, role).pipe(
      map(jwtResp => jwtResp.accessToken),
      tap((token: string) => {
        // Save token to localStorage
        this.localStorage.setItem('accessToken', token);
        // Redirect to main
        this.router.navigate(['/photos']);
      })
    );
  }

  isAuthenticated(): boolean {
    return !!this.localStorage.getItem('accessToken');
  }
}
