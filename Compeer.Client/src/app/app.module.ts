import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AuthService } from './_services/auth.service';
import { AuthGuardService as AuthGuard } from './_services/auth-guard.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminMenuComponent } from './layout/admin-menu/admin-menu.component';
import { AsideMenuComponent } from './layout/aside-menu/aside-menu.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LogoComponent } from './layout/logo/logo.component';
import { NotificationsMenuComponent } from './layout/notifications-menu/notifications-menu.component';
import { QuickActionsMenuComponent } from './layout/quick-actions-menu/quick-actions-menu.component';
import { SearchBarComponent } from './layout/search-bar/search-bar.component';
import { TopBarComponent } from './layout/top-bar/top-bar.component';
import { TopMenuComponent } from './layout/top-menu/top-menu.component';
import { UserMenuComponent } from './layout/user-menu/user-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    AdminMenuComponent,
    AsideMenuComponent,
    FooterComponent,
    LogoComponent,
    NotificationsMenuComponent,
    QuickActionsMenuComponent,
    SearchBarComponent,
    TopBarComponent,
    TopMenuComponent,
    UserMenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate:[AuthGuard]},
      { path: 'login', component:LoginComponent}
    ])
  ],
  providers: [AuthGuard,AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
