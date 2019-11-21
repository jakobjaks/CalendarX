import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";
import { IdentityService } from "services/identity-service";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('Identity.Register');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Register {

  private email: string;
  private password: string;
  private confirmPassword: string;


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
  submit(): void {
    log.debug("submit", this.email, this.password);
    if (this.password==null || this.confirmPassword==null || this.email == null ||
      this.password != this.confirmPassword || this.password.length < 6 ||
      this.email.length == 0){
      alert('Passwords dont match or password too short or username too short!');
      return;
    }

    this.identityService.register(this.email, this.password)
      .then(jwtDTO => {
        if (jwtDTO.token !== undefined) {
          log.debug("submit token", jwtDTO.token);
          this.appConfig.jwt = jwtDTO.token;
          this.router.navigateToRoute('home');
        }
      });
  }

}
