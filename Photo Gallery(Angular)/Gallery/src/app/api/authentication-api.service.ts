import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {publishReplay, refCount} from "rxjs/operators";
import {environment} from "../../environments/environment";

interface JwtResponse {
  accessToken: string;
}

@Injectable()
export class AuthenticationApiService {

  constructor(
    private readonly http: HttpClient,
  ) {
  }

  registration(email: string, password: string){
    return this.http.post(
      [
        environment.apiUrl,
        'auth',
        'register'
      ].join('/'),
      {
        email,
        password
      }
    ).pipe(
      publishReplay(1),
      refCount()
    )
  }

  login(email: string, password: string, role: string): Observable<JwtResponse> {
    return this.http.post<JwtResponse>(
      [
        environment.apiUrl,
        'auth',
        'login'
      ].join('/'),
      {
        email,
        password,
        role
      },
      {
        headers: {
          'Authorization': 'Bearer token'
        }
      }
    ).pipe(
      publishReplay(1),
      refCount()
    )
  }
}
