import React from 'react';
import { Typography } from '@material-ui/core';

function FuseSplashScreen()
{
    return (
        <div id="fuse-splash-screen">

            <div className="center">

                <div >
                    <Typography className="hidden sm:flex" variant="h6">Exago</Typography>
                </div>
                <div className="spinner-wrapper">
                    <div className="spinner">
                        <div className="inner">
                            <div className="gap"/>
                            <div className="left">
                                <div className="half-circle"/>
                            </div>
                            <div className="right">
                                <div className="half-circle"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default React.memo(FuseSplashScreen);
