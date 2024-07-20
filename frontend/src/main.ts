import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';

declare var bootstrap: any;

bootstrapApplication(AppComponent, appConfig)
  .then(() => {
    if (typeof bootstrap !== 'undefined') {
      console.log('Bootstrap is loaded');
    } else {
      console.log('Bootstrap is not loaded');
    }
  })
  .catch((err) => console.error(err));
