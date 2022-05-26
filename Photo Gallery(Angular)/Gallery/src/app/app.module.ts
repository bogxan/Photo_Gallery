import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {AuthenticationModule} from "./authentication/authentication.module";
import {SharedModule} from "./shared.module";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AuthGuard} from "./shared/guards/auth.guard";
import {BrowserLocalStorage} from "./shared/storage/local-storage";
import {HTTP_INTERCEPTORS} from "@angular/common/http";
import {QueryHttpInterceptor} from "./shared/http/query-http.interceptor";
import {MainModule} from "./main/main.module";
import {ServicesApiModule} from "./api/services-api.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthenticationModule,
    SharedModule,
    BrowserAnimationsModule,
    MainModule,
    ServicesApiModule
  ],
  providers: [
    AuthGuard,
    BrowserLocalStorage,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: QueryHttpInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
