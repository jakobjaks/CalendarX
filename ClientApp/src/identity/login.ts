import { IdentityService } from '../services/identity-service';
import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import { AppConfig } from 'app-config';

export var log = LogManager.getLogger('Identity.Login');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Login {

  // TODO: Remove fixed username and password
  private email: string = "a@gmail.ee";
  private password: string = "123456";

  constructor(
    private identityService: IdentityService,
    private appConfig: AppConfig,
    private router: Router
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

  // ==================== View methods ================
  submit():void{
    log.debug("submit", this.email, this.password);
    this.identityService.login(this.email, this.password)
      .then(jwtDTO => {
        if (jwtDTO.token !== undefined){
          log.debug("submit token", jwtDTO.token);
          this.appConfig.jwt = jwtDTO.token;
          console.log("WE HERE")
          console.log(this.appConfig.jwt);
          this.router.navigateToRoute('home');
        }
      });
  }
}
