import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ITargetAudience} from "../../interfaces/ITargetAudience";
import {TargetAudienceService} from "../../services/targetaudiences-service";

export var log = LogManager.getLogger('TargetAudiences.Create');

@autoinject
export class Create {

  private TargetAudience: ITargetAudience;

  constructor(
    private router: Router,
    private TargetAudiencesService: TargetAudienceService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('TargetAudience', this.TargetAudience);
    this.TargetAudiencesService.post(this.TargetAudience).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("TargetAudiencesIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
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
}
