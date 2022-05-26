import {NgModule} from "@angular/core";
import {PhotoComponent} from "../photo/photo.component";
import {PhotosComponent} from "./photos.component";
import {PhotosService} from "./photos.service";
import {BrowserModule} from "@angular/platform-browser";
import {RouterModule} from "@angular/router";
import {CreatePhotoComponent} from "../create-photo/create-photo.component";
import {AppRoutingModule} from "../../../app-routing.module";
import {EditPhotoComponent} from "../edit-photo/edit-photo.component";
import {ReactiveFormsModule} from "@angular/forms";
import {PostFeedbackComponent} from "../post-feedback/post-feedback.component";
import {FeedbacksComponent} from "../feedbacks/feedbacks.component";
import {HttpClientModule} from "@angular/common/http";
import {ServicesApiModule} from "../../../api/services-api.module";

@NgModule({
  declarations:[
    PhotosComponent,
    PhotoComponent,
    CreatePhotoComponent,
    EditPhotoComponent,
    PostFeedbackComponent,
    FeedbacksComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ServicesApiModule
  ],
  exports: [
    PhotosComponent
  ],
  providers:[
    PhotosService
  ]
})
export class PhotosModule{

}
