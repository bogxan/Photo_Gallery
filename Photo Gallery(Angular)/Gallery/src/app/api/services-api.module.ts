import {NgModule} from "@angular/core";
import {GalleryApiService} from "./gallery/gallery-api.service";
import {AuthenticationApiService} from "./authentication-api.service";

@NgModule({
  providers:[GalleryApiService, AuthenticationApiService],
  exports: [],
  imports: [],
  declarations:[]
})
export class ServicesApiModule{

}
